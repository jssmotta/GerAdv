"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ProPartesInc from "../Crud/Inc/ProPartes";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ProPartesIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ProPartesIncContainer: React.FC<ProPartesIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/propartes"); // 27012025
    const handleError = () => { };

    return (
        <ProPartesInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ProPartesIncContainer;