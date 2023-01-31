/*
 * Web.Api
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 *
 * Swagger Codegen version: 3.0.39
 *
 * Do not edit the class manually.
 *
 */
import {ApiClient} from '../ApiClient';
import {NewAnswerDto} from './NewAnswerDto';

/**
 * The NewAttemptDto model module.
 * @module model/NewAttemptDto
 * @version v1
 */
export class NewAttemptDto {
  /**
   * Constructs a new <code>NewAttemptDto</code>.
   * @alias module:model/NewAttemptDto
   * @class
   */
  constructor() {
  }

  /**
   * Constructs a <code>NewAttemptDto</code> from a plain JavaScript object, optionally creating a new instance.
   * Copies all relevant properties from <code>data</code> to <code>obj</code> if supplied or a new instance if not.
   * @param {Object} data The plain JavaScript object bearing properties of interest.
   * @param {module:model/NewAttemptDto} obj Optional instance to populate.
   * @return {module:model/NewAttemptDto} The populated <code>NewAttemptDto</code> instance.
   */
  static constructFromObject(data, obj) {
    if (data) {
      obj = obj || new NewAttemptDto();
      if (data.hasOwnProperty('testId'))
        obj.testId = ApiClient.convertToType(data['testId'], 'Number');
      if (data.hasOwnProperty('answers'))
        obj.answers = ApiClient.convertToType(data['answers'], [NewAnswerDto]);
    }
    return obj;
  }
}

/**
 * @member {Number} testId
 */
NewAttemptDto.prototype.testId = undefined;

/**
 * @member {Array.<module:model/NewAnswerDto>} answers
 */
NewAttemptDto.prototype.answers = undefined;

