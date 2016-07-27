package com.sessionm.models;

/**
 * Created by ngadre on 10/26/15.
 {
     "user": {
     "external_id": "28cf052c31504944aa945236dcdf283b",
     "email": "WNADQA@example.com",
     "gender": "f",
     "dob": "1990-01-01",
     "ip": "127.0.0.1"
     }
 }
 */

import java.util.HashMap;
import java.util.Map;
import com.fasterxml.jackson.annotation.JsonAnyGetter;
import com.fasterxml.jackson.annotation.JsonAnySetter;
import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.annotation.JsonProperty;
import org.apache.commons.lang.builder.ToStringBuilder;

@JsonInclude(JsonInclude.Include.NON_NULL)
public class User {

    @JsonProperty("external_id")
    private String externalId;
    @JsonProperty("id")
    private String id;
    @JsonProperty("email")
    private String email;
    @JsonProperty("gender")
    private String gender;
    @JsonProperty("dob")
    private String dob;
    @JsonProperty("created_at")
    private String createdAt;
    @JsonProperty("updated_at")
    private String updatedAt;
    @JsonProperty("city")
    private String city;
    @JsonProperty("zip")
    private String zip;
    @JsonProperty("dma")
    private String dma;
    @JsonProperty("ip")
    private String ip;
    @JsonProperty("suspended")
    private Boolean suspended;
    @JsonProperty("tier")
    private String tier;
    @JsonProperty("next_tier_percentage")
    private Double nextTierPercentage;
    @JsonProperty("account_status")
    private String accountStatus;
    @JsonProperty("tier_system")
    private String tierSystem;
    @JsonProperty("available_points")
    private Integer availablePoints;
    @JsonProperty("test_points")
    private Integer testPoints;
    @JsonProperty("unclaimed_achievement_count")
    private Integer unclaimedAchievementCount;
    @JsonProperty("test_account")
    private Boolean testAccount;
    @JsonProperty("user_profile")
    private Map<String, Object> user_profile = new HashMap<String, Object>();

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

    public User withId(String id) {
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
     * @return
     * The email
     */
    @JsonProperty("email")
    public String getEmail() {
        return email;
    }

    /**
     *
     * @param email
     * The email
     */
    @JsonProperty("email")
    public void setEmail(String email) {
        this.email = email;
    }

    public User withEmail(String email) {
        this.email = email;
        return this;
    }

    /**
     *
     * @return
     * The gender
     */
    @JsonProperty("gender")
    public String getGender() {
        return gender;
    }

    /**
     *
     * @param gender
     * The gender
     */
    @JsonProperty("gender")
    public void setGender(String gender) {
        this.gender = gender;
    }

    public User withGender(String gender) {
        this.gender = gender;
        return this;
    }

    /**
     *
     * @return
     * The dob
     */
    @JsonProperty("dob")
    public String getDob() {
        return dob;
    }

    /**
     *
     * @param dob
     * The dob
     */
    @JsonProperty("dob")
    public void setDob(String dob) {
        this.dob = dob;
    }

    public User withDob(String dob) {
        this.dob = dob;
        return this;
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

    public User withCreatedAt(String createdAt) {
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

    public User withUpdatedAt(String updatedAt) {
        this.updatedAt = updatedAt;
        return this;
    }

    /**
     *
     * @return
     * The city
     */
    @JsonProperty("city")
    public String getCity() {
        return city;
    }

    /**
     *
     * @param city
     * The city
     */
    @JsonProperty("city")
    public void setCity(String city) {
        this.city = city;
    }

    public User withCity(String city) {
        this.city = city;
        return this;
    }

    /**
     *
     * @return
     * The zip
     */
    @JsonProperty("zip")
    public String getZip() {
        return zip;
    }

    /**
     *
     * @param zip
     * The zip
     */
    @JsonProperty("zip")
    public void setZip(String zip) {
        this.zip = zip;
    }

    public User withZip(String zip) {
        this.zip = zip;
        return this;
    }

    /**
     *
     * @return
     * The dma
     */
    @JsonProperty("dma")
    public String getDma() {
        return dma;
    }

    /**
     *
     * @param dma
     * The dma
     */
    @JsonProperty("dma")
    public void setDma(String dma) {
        this.dma = dma;
    }

    public User withDma(String dma) {
        this.dma = dma;
        return this;
    }

    /**
     *
     * @return
     * The suspended
     */
    @JsonProperty("suspended")
    public Boolean getSuspended() {
        return suspended;
    }

    /**
     *
     * @param suspended
     * The suspended
     */
    @JsonProperty("suspended")
    public void setSuspended(Boolean suspended) {
        this.suspended = suspended;
    }

    public User withSuspended(Boolean suspended) {
        this.suspended = suspended;
        return this;
    }

    /**
     *
     * @return
     * The tier
     */
    @JsonProperty("tier")
    public String getTier() {
        return tier;
    }

    /**
     *
     * @param tier
     * The tier
     */
    @JsonProperty("tier")
    public void setTier(String tier) {
        this.tier = tier;
    }

    public User withTier(String tier) {
        this.tier = tier;
        return this;
    }

    /**
     *
     * @return
     * The nextTierPercentage
     */
    @JsonProperty("next_tier_percentage")
    public Double getNextTierPercentage() {
        return nextTierPercentage;
    }

    /**
     *
     * @param nextTierPercentage
     * The next_tier_percentage
     */
    @JsonProperty("next_tier_percentage")
    public void setNextTierPercentage(Double nextTierPercentage) {
        this.nextTierPercentage = nextTierPercentage;
    }

    public User withNextTierPercentage(Double nextTierPercentage) {
        this.nextTierPercentage = nextTierPercentage;
        return this;
    }

    /**
     *
     * @return
     * The accountStatus
     */
    @JsonProperty("account_status")
    public String getAccountStatus() {
        return accountStatus;
    }

    /**
     *
     * @param accountStatus
     * The account_status
     */
    @JsonProperty("account_status")
    public void setAccountStatus(String accountStatus) {
        this.accountStatus = accountStatus;
    }

    public User withAccountStatus(String accountStatus) {
        this.accountStatus = accountStatus;
        return this;
    }

    /**
     *
     * @return
     * The ip
     */
    @JsonProperty("ip")
    public String getIp() {
        return ip;
    }

    /**
     *
     * @param ip
     * The ip
     */
    @JsonProperty("ip")
    public void setIp(String ip) {
        this.ip = ip;
    }


    /**
     *
     * @return tierSystem
     * The tier System
     */
    public String getTierSystem() {
        return tierSystem;
    }

    /**
     *
     * @param tierSystem
     * The tier System
     */
    public void setTierSystem(String tierSystem) {
        this.tierSystem = tierSystem;
    }


    /**
     *
     * @return  availablePoints
     * The total number of Points balance of a User. Total point balance does not include Test Points
     */
    public Integer getAvailablePoints() {
        return availablePoints;
    }

    /**
     *
     * @param availablePoints
     * The total number of Points balance of a User. Total point balance does not include Test Points
     */
    public void setAvailablePoints(Integer availablePoints) {
        this.availablePoints = availablePoints;
    }

    /**
     *
     * @return  testPoints
     * The total number of Test Points balance.
     */
    public Integer getTestPoints() {
        return testPoints;
    }

    /**
     *
     * @param testPoints
     * The total number of Test Points balance.
     */
    public void setTestPoints(Integer testPoints) {
        this.testPoints = testPoints;
    }

    /**
     *
     * @return  unclaimedAchievementCount
     * The unclaimed achievement Count
     */
    public Integer getUnclaimedAchievementCount() {
        return unclaimedAchievementCount;
    }

    /**
     *
     * @param unclaimedAchievementCount
     * The unclaimed achievement Count
     */
    public void setUnclaimedAchievementCount(Integer unclaimedAchievementCount) {
        this.unclaimedAchievementCount = unclaimedAchievementCount;
    }

    /**
     *
     * @return testAccount
     * Flag indicate if account is Test or Not. 'true' indicates Account is marked as Test
     */
    public Boolean getTestAccount() {
        return testAccount;
    }

    /**
     *
     * @param  testAccount
     * Flag indicate if account is Test or Not. 'true' indicates Account is marked as Test
     */
    public void setTestAccount(Boolean testAccount) {
        this.testAccount = testAccount;
    }

    @Override
    public String toString() {
        return ToStringBuilder.reflectionToString(this);
    }

    @JsonAnyGetter
    public Map<String, Object> getUser_profile() {
        return this.user_profile;
    }

    @JsonAnySetter
    public void setUser_profile(String name, Object value) {
        this.user_profile.put(name, value);
    }

    public User withUser_profile(String name, Object value) {
        this.user_profile.put(name, value);
        return this;
    }

    public void removeUserProfile() {
        this.user_profile = null;
    }

}