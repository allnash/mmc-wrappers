package com.sessionm.jsonservice;

import com.typesafe.config.Config;
import com.typesafe.config.ConfigFactory;
import org.apache.http.HttpResponse;
import org.apache.http.auth.AuthScope;
import org.apache.http.auth.UsernamePasswordCredentials;
import org.apache.http.client.CredentialsProvider;
import org.apache.http.client.methods.HttpDelete;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.methods.HttpPut;
import org.apache.http.entity.ContentType;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.BasicCredentialsProvider;
import org.apache.http.impl.nio.client.CloseableHttpAsyncClient;
import org.apache.http.impl.nio.client.HttpAsyncClients;

import java.util.concurrent.Future;

/**
 * Created by ngadre on 10/26/15.
 */
public class AsyncClient {

    final static CloseableHttpAsyncClient HTTP_ASYNC_CLIENT = AsyncClient.basicAuthHttpClient();
    public static Config SESSIONM_LIBRARY_CONFIG;

    private static void loadConfigs() {
        if(SESSIONM_LIBRARY_CONFIG == null)
            SESSIONM_LIBRARY_CONFIG = ConfigFactory.load("SMServiceConfig");
    }

    private static CloseableHttpAsyncClient basicAuthHttpClient(){

        AsyncClient.loadConfigs();
        CredentialsProvider credsProvider = new BasicCredentialsProvider();
        credsProvider.setCredentials(
                new AuthScope(SESSIONM_LIBRARY_CONFIG.getString("sessionm.api_host"), 443),
                new UsernamePasswordCredentials(SESSIONM_LIBRARY_CONFIG.getString("sessionm.property.api_key"), SESSIONM_LIBRARY_CONFIG.getString("sessionm.property.secret")));
        return HttpAsyncClients.custom()
                .setDefaultCredentialsProvider(credsProvider)
                .build();
    }

    public static Future<HttpResponse> get(String urlPath){
        HTTP_ASYNC_CLIENT.start();
        HttpGet request = new HttpGet(urlPath);
        Future<HttpResponse> future = HTTP_ASYNC_CLIENT.execute(request, null);
        return future;
    }

    public static Future<HttpResponse> post(String urlPath,String jsonData){
        HTTP_ASYNC_CLIENT.start();
        HttpPost request = new HttpPost(urlPath);
        request.setEntity(new StringEntity(jsonData, ContentType.APPLICATION_JSON));
        Future<HttpResponse> future = HTTP_ASYNC_CLIENT.execute(request, null);
        return future;
    }

    public static Future<HttpResponse> put(String urlPath,String jsonData){
        HTTP_ASYNC_CLIENT.start();
        HttpPut request = new HttpPut(urlPath);
        request.setEntity(new StringEntity(jsonData, ContentType.APPLICATION_JSON));
        Future<HttpResponse> future = HTTP_ASYNC_CLIENT.execute(request, null);
        return future;
    }

    public static Future<HttpResponse> delete(String urlPath){
        HTTP_ASYNC_CLIENT.start();
        HttpDelete request = new HttpDelete(urlPath);
        Future<HttpResponse> future = HTTP_ASYNC_CLIENT.execute(request, null);
        return future;
    }

}
