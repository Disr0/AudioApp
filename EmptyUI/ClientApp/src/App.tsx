import { useState } from "react";
import { useEffect } from "react";
import { UserApi } from "./features/user/user.api";
import type { UserVm } from "./features/user/user.models";


export const App = () => {

    const [users, setUsers] = useState<Array<UserVm>>([]);

    const [isLoading, seIsLoading] = useState(false);

    useEffect(() => {
        seIsLoading(true);

        UserApi.getList()
            .then(res => {
                setUsers(res.data);
            })
            .finally(() => {
                seIsLoading(false)
            });
    });

    return <>
        <div>new react app!</div>

        <table>
            <tr>
                <th>id</th>
                <th>name</th>
                <th>age</th>
            </tr>
            {
                isLoading
                    ? '...Load'
                    : users.map(x =>
                        <tr>
                            <td>{x.id}</td>
                            <td>{x.name}</td>
                            <td>{x.age}</td>
                        </tr>
                    )
            }
        </table>

    </>;
};

