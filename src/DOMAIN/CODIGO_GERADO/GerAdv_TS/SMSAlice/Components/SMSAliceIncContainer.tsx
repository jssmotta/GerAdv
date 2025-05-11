"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import SMSAliceInc from "../Crud/Inc/SMSAlice";
import { getParamFromUrl } from "@/app/tools/helpers";

interface SMSAliceIncContainerProps {
    id: number;
    navigator: INavigator;
}

const SMSAliceIncContainer: React.FC<SMSAliceIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/smsalice"); // 27012025
    const handleError = () => { };

    return (
        <SMSAliceInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default SMSAliceIncContainer;