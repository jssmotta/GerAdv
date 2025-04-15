"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import AlertasInc from "../Crud/Inc/Alertas";
import { getParamFromUrl } from "@/app/tools/helpers";

interface AlertasIncContainerProps {
    id: number;
    navigator: INavigator;
}

const AlertasIncContainer: React.FC<AlertasIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/alertas"); // 27012025
    const handleError = () => { };

    return (
        <AlertasInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default AlertasIncContainer;