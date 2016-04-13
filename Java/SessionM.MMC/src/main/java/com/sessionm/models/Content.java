package com.sessionm.models;

/**
 * Created by ngadre on 10/26/15.
 {
    "content": {
                 "created_at": "2015-12-03 17:18:42",
                 "data": {
                     "number": 1
                 },
                 "description": "home page blog ad",
                 "expires_on": "2017-12-03 17:18:42",
                 "external_id": "content_number_data_1",
                 "id": 69,
                 "metadata": {
                     "carrier": [
                        "verizon"
                     ],
                     "deviceGroup": [
                        "galaxy"
                     ],
                     "genderTags": [
                        "m"
                     ],
                     "keywords": "blog,new product,buy now,advertising",
                     "tags": "hashtag, samsung, phone"
                 },
                 "name": "Number data",
                 "state": "preview",
                 "type": "sample_number_data",
                 "updated_at": "2016-04-06 00:44:34",
                 "weight": 10
                 },
    "status": "ok"
 }
 */

import com.fasterxml.jackson.annotation.JsonAnyGetter;
import com.fasterxml.jackson.annotation.JsonAnySetter;
import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.annotation.JsonProperty;
import org.apache.commons.lang.builder.ToStringBuilder;

import java.util.HashMap;
import java.util.Map;

@JsonInclude(JsonInclude.Include.NON_NULL)
public class Content {

    @JsonProperty("external_id")
    private String externalId;
    @JsonProperty("id")
    private String id;
    @JsonProperty("name")
    private String name;
    @JsonProperty("description")
    private String description;
    @JsonProperty("image")
    private String image;
    @JsonProperty("created_at")
    private String createdAt;
    @JsonProperty("updated_at")
    private String updatedAt;
    @JsonProperty("state")
    private String state;
    @JsonProperty("type")
    private String type;
    @JsonProperty("weight")
    private Integer weight;
    @JsonProperty("data")
    private Map<String, Object> data = new HashMap<String, Object>();

    /**
     *
     * @return
     * The id
     */
    @JsonProperty("id")
    public String getId() {
        return id;
    }

    /**
     *
     * @param id
     * The id
     */
    @JsonProperty("id")
    public void setId(String id) {
        this.id = id;
    }

    public Content withId(String id) {
        this.id = id;
        return this;
    }

    /**
     *
     * @return
     * The externalId
     */
    @JsonProperty("external_id")
    public String getExternalId() {
        return externalId;
    }

    /**
     *
     * @param externalId
     * The id
     */
    @JsonProperty("external_id")
    public void setExternalId(String externalId) {
        this.externalId = externalId;
    }

    /**
     *
     * @return name
     * The name
     */
    @JsonProperty("name")
    public String getName() {
        return name;
    }

    /**
     *
     * @param name
     * The name
     */
    @JsonProperty("name")
    public void setName(String name) {
        this.name = name;
    }

    /**
     *
     * @return  description
     * The description
     */
    @JsonProperty("description")
    public String getDescription() {
        return description;
    }

    /**
     *
     * @param description
     * The description
     */
    @JsonProperty("description")
    public void setDescription(String description) {
        this.description = description;
    }

    /**
     *
     * @return  image
     * The image URL
     */
    @JsonProperty("image")
    public String getImage() {
        return image;
    }

    /**
     *
     * @param image
     * The image URL
     */
    @JsonProperty("image")
    public void setImage(String image) {
        this.image = image;
    }

    /**
     *
     * @return  state
     * The state
     */
    @JsonProperty("state")
    public String getState() {
        return state;
    }

    /**
     *
     * @param state
     * The state
     */
    @JsonProperty("state")
    public void setState(String state) {
        this.state = state;
    }

    /**
     *
     * @return type
     * The type
     */
    @JsonProperty("type")
    public String getType() {
        return type;
    }

    /**
     *
     * @param type
     * The type
     */
    @JsonProperty("type")
    public void setType(String type) {
        this.type = type;
    }

    /**
     *
     * @return weight
     * The weight
     */
    @JsonProperty("weight")
    public Integer getWeight() {
        return weight;
    }

    /**
     *
     * @param weight
     * The weight
     */
    @JsonProperty("weight")
    public void setWeight(Integer weight) {
        this.weight = weight;
    }

    /**
     *
     * @return
     * The createdAt
     */
    @JsonProperty("created_at")
    public String getCreatedAt() {
        return createdAt;
    }

    /**
     *
     * @param createdAt
     * The created_at
     */
    @JsonProperty("created_at")
    public void setCreatedAt(String createdAt) {
        this.createdAt = createdAt;
    }

    public Content withCreatedAt(String createdAt) {
        this.createdAt = createdAt;
        return this;
    }

    /**
     *
     * @return
     * The updatedAt
     */
    @JsonProperty("updated_at")
    public String getUpdatedAt() {
        return updatedAt;
    }

    /**
     *
     * @param updatedAt
     * The updated_at
     */
    @JsonProperty("updated_at")
    public void setUpdatedAt(String updatedAt) {
        this.updatedAt = updatedAt;
    }

    public Content withUpdatedAt(String updatedAt) {
        this.updatedAt = updatedAt;
        return this;
    }

    @Override
    public String toString() {
        return ToStringBuilder.reflectionToString(this);
    }

    @JsonAnyGetter
    public Map<String, Object> getData() {
        return this.data;
    }

    @JsonAnySetter
    public void setData(String name, Object value) {
        this.data.put(name, value);
    }

    public Content withUser_profile(String name, Object value) {
        this.data.put(name, value);
        return this;
    }
}