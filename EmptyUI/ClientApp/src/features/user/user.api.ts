import { httpClient } from "../../httpClient";
import type { IUserFilterVm, UserVm } from "./user.models";

const endpoints = {
    GET_LIST: "/User/GetList",
}

export class UserApi {

    static getList(params?: IUserFilterVm,) {
        return httpClient.get<Array<UserVm>>(endpoints.GET_LIST, { params});
    };

}