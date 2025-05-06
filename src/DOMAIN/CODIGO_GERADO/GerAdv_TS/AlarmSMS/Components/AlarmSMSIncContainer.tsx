"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import AlarmSMSInc from "../Crud/Inc/AlarmSMS";
import { getParamFromUrl } from "@/app/tools/helpers";

interface AlarmSMSIncContainerProps {
    id: number;
    navigator: INavigator;
}

const AlarmSMSIncContainer: React.FC<AlarmSMSIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/alarmsms"); // 27012025
    const handleError = () => { };

    return (
        <AlarmSMSInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default AlarmSMSIncContainer;