package com.sessionm.api.factory;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.JsonNode;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.sessionm.api.APIRoutes;
import com.sessionm.jsonservice.AsyncClient;
import com.sessionm.jsonservice.SMRequest;
import com.sessionm.jsonservice.SMResponse;
import com.sessionm.models.Content;
import org.apache.http.HttpResponse;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Date;
import java.util.Map;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

/**
 * Created by ngadre on 4/5/16.
 */
public class ContentFactory {

    public static Future<Content> createContent(String externalId, String name, String description, String state, String type, String image, JsonNode dataJsonNode, JsonNode metadataJsonNode, Date created_at, Date expires_on,Integer weight)
    {
        // thread pool size 5
        ExecutorService executor = Executors.newFixedThreadPool(5);

        SMRequest createContentRequest = new SMRequest();
        Content myContent = new Content();
        myContent.setExternalId(externalId);
        myContent.setName(name);
        myContent.setDescription(description);
        myContent.setType(type);
        myContent.setWeight(weight);
        myContent.setExternalId(externalId);
        myContent.setImage(image);
        createContentRequest.setContent(myContent);

        ObjectMapper objectMapper = new ObjectMapper();
        String textValue = null;
        try {
            if(dataJsonNode != null){
                textValue = objectMapper.writeValueAsString(dataJsonNode);
                Map<String, Object> data = objectMapper.readValue(textValue, new TypeReference<Map<String, String>>(){});
                myContent.setData("data",data);
            }

            if(metadataJsonNode != null) {
                textValue = objectMapper.writeValueAsString(metadataJsonNode);
                Map<String, Object> metadata = objectMapper.readValue(textValue, new TypeReference<Map<String, String>>() {
                });
                myContent.setData("metadata", metadata);
            }

        } catch (JsonProcessingException e) {
            e.printStackTrace();
        } catch (IOException e){
            e.printStackTrace();
        }

        String json = null;

        try {

            json = objectMapper.writeValueAsString(createContentRequest);

        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }

        Future<HttpResponse> responseString = AsyncClient.post(APIRoutes.createUserRoute(), json);
        Future<Content> future = executor.submit(new CallableTask(responseString));

        return future;

    }

    static class CallableTask implements Callable<Content> {

        private Future<HttpResponse> responseString;

        public CallableTask(Future<HttpResponse> responseString){
            this.responseString = responseString;
        }

        @Override
        public Content call() throws Exception {

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
            return m.getContent();
        }

    }
}
