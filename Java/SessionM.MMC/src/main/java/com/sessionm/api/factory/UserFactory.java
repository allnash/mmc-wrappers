package com.sessionm.api.factory;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.sessionm.api.APIRoutes;
import com.sessionm.jsonservice.AsyncClient;
import com.sessionm.jsonservice.SMRequest;
import com.sessionm.jsonservice.SMResponse;
import com.sessionm.models.User;
import org.apache.http.HttpResponse;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

/**
 * Created by ngadre on 10/26/15.
 */


public class UserFactory
{
    public enum UserGender
    {
        m, f
    }

    public static Future<User> createUser(String externalId, String email, UserGender gender, Date dob, String ipAddress)
    {
        // thread pool size 5
        ExecutorService executor = Executors.newFixedThreadPool(5);

        SimpleDateFormat dt = new SimpleDateFormat("yyyy-mm-dd");
        SMRequest createUserRequest = new SMRequest();
        User myUser = new User();
        myUser.setExternalId(externalId);
        myUser.setEmail(email);
        myUser.setGender(gender.name());
        myUser.setIp(ipAddress);
        myUser.setDob(dt.format(dob));
        myUser.removeUserProfile();
        createUserRequest.setUser(myUser);

        ObjectMapper objectMapper = new ObjectMapper();
        String json = null;
        try {

            json = objectMapper.writeValueAsString(createUserRequest);

        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }

        Future<HttpResponse> responseString = AsyncClient.post(APIRoutes.createUserRoute(), json);
        Future<User> future = executor.submit(new CallableTask(responseString));

        return future;

    }

    public static Future<User> fetchUserWithId(String id)
    {
        // thread pool size 5
        ExecutorService executor = Executors.newFixedThreadPool(5);
        Future<HttpResponse> responseString = AsyncClient.get(APIRoutes.fetchUserWithIdRoute() + id);

        Future<User> future = executor.submit(new CallableTask(responseString));

        return future;

    }

    public static Future<User> fetchUserWithExternalId(String id)
    {
        // thread pool size 5
        ExecutorService executor = Executors.newFixedThreadPool(5);
        Future<HttpResponse> responseString = AsyncClient.get(APIRoutes.fetchUserWithExternalIdRoute() + id);
        Future<User> future = executor.submit(new CallableTask(responseString));
        return future;

    }

     static class CallableTask implements Callable<User> {

         private Future<HttpResponse> responseString;

         public CallableTask(Future<HttpResponse> responseString){
            this.responseString = responseString;
         }

         @Override
         public User call() throws Exception {

             BufferedReader rd = new BufferedReader(
                     new InputStreamReader(responseString.get().getEntity().getContent()));

             StringBuffer result = new StringBuffer();
             String line = "";

             while ((line = rd.readLine()) != null) {
                 result.append(line);
             }

             byte[] jsonData = result.toString().getBytes();
             ObjectMapper objectMapper = new ObjectMapper();
             SMResponse m =  objectMapper.readValue(jsonData, SMResponse.class);
             return m.getUser();
         }

    }
}