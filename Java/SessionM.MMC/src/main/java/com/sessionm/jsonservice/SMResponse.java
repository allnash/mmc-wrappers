package com.sessionm.jsonservice;

/**
 * Created by ngadre on 10/26/15.
 */


import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import javax.annotation.Generated;
import com.fasterxml.jackson.annotation.JsonAnyGetter;
import com.fasterxml.jackson.annotation.JsonAnySetter;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonPropertyOrder;
import com.sessionm.models.Errors;
import com.sessionm.models.User;
import org.apache.commons.lang.builder.ToStringBuilder;



@JsonInclude(JsonInclude.Include.NON_NULL)
@Generated("org.jsonschema2pojo")
@JsonPropertyOrder({
        "status",
        "user"
})
public class SMResponse {

    @JsonProperty("status")
    private String status;
    @JsonProperty("errors")
    private Errors errors;
//    @JsonProperty("model")
//    private Model model;
//    @JsonProperty("offers")
//    private List<Offer> offers = new ArrayList<String>();
//    @JsonProperty("order")
//    private Order order;
    @JsonProperty("user")
    private User user;

    @JsonIgnore
    private Map<String, Object> additionalProperties = new HashMap<String, Object>();

    /**
     *
     * @return
     * The status
     */
    @JsonProperty("status")
    public String getStatus() {
        return status;
    }

    /**
     *
     * @param status
     * The status
     */
    @JsonProperty("status")
    public void setStatus(String status) {
        this.status = status;
    }

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

    /**
     *
     * @return
     * The errors
     */
    @JsonProperty("errors")
    public Errors getErrors() {
        return errors;
    }

    /**
     *
     * @param errors
     * The errors
     */
    @JsonProperty("errors")
    public void setErrors(Errors errors) {
        this.errors = errors;
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


}
