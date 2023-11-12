import 'bootstrap/dist/css/bootstrap.min.css';
import './styles.css'
import { UserTable } from "./features/user/components";
import { Button, Form, Modal } from 'react-bootstrap';
import { useState } from 'react';
import { UserApi } from './features/user/user.api';
import { AddUserModal } from './features/user/components/UserAddModal';


export const App = () => {
    const [show, setShow] = useState(false);
    const handleOpen = () => setShow(true);
    const createUser = (event : any) => UserApi.createUser();

    return <>
        <div className="tableDiv">
            <UserTable />
        </div>
        <div className="buttonsDiv">
            <div className="actions">Actions</div>
            <Button variant="primary" onClick={handleOpen} className="button">Add user</Button>
        </div>
        
        <AddUserModal showState={show} setShow={setShow}/>
    </>;
};

