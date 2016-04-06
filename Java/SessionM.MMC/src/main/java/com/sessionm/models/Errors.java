package com.sessionm.models;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * Created by ngadre on 12/10/15.
 */
public class Errors {

    @JsonProperty("message")
    private String message;

    /**
     *
     * @return
     * The message
     */
    @JsonProperty("message")
    public String getMessage() {
        return message;
    }

    /**
     *
     * @param message
     * The message
     */
    @JsonProperty("message")
    public void setMessage(String message) {
        this.message = message;
    }

}