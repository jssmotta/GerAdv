"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import Apenso2Inc from "../Crud/Inc/Apenso2";
import { getParamFromUrl } from "@/app/tools/helpers";

interface Apenso2IncContainerProps {
    id: number;
    navigator: INavigator;
}

const Apenso2IncContainer: React.FC<Apenso2IncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/apenso2"); // 27012025
    const handleError = () => { };

    return (
        <Apenso2Inc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default Apenso2IncContainer;