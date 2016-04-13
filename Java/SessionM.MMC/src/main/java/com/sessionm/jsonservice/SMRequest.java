package com.sessionm.jsonservice;

/**
 * Created by ngadre on 10/26/15.
 */


import java.util.HashMap;
import java.util.Map;
import com.fasterxml.jackson.annotation.JsonAnyGetter;
import com.fasterxml.jackson.annotation.JsonAnySetter;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonPropertyOrder;
import com.sessionm.models.Content;
import com.sessionm.models.User;
import org.apache.commons.lang.builder.ToStringBuilder;

@JsonInclude(JsonInclude.Include.NON_NULL)
@JsonPropertyOrder({
        "user"
})
public class SMRequest {

    @JsonProperty("user")
    private User user;
    @JsonProperty("content")
    private Content content;
    @JsonIgnore
    private Map<String, Object> additionalProperties = new HashMap<String, Object>();

    /**
     *
     * @return
     * The user
     */
    @JsonProperty("user")
    public User getUser() {
        return user;
    }

    /**
     *
     * @param user
     * The user
     */
    @JsonProperty("user")
    public void setUser(User user) {
        this.user = user;
    }

    public SMRequest withUser(User user) {
        this.user = user;
        return this;
    }

    /**
    * @return content
    * The content
    */
    @JsonProperty("content")
    public Content getContent() {
        return content;
    }

    /**
     *
     * @param content
     * The content
     */
    @JsonProperty("content")
    public void setContent(Content content) {
        this.content = content;
    }

    @Override
    public String toString() {
        return ToStringBuilder.reflectionToString(this);
    }

    @JsonAnyGetter
    public Map<String, Object> getAdditionalProperties() {
        return this.additionalProperties;
    }

    @JsonAnySetter
    public void setAdditionalProperty(String name, Object value) {
        this.additionalProperties.put(name, value);
    }

    public SMRequest withAdditionalProperty(String name, Object value) {
        this.additionalProperties.put(name, value);
        return this;
    }

}
