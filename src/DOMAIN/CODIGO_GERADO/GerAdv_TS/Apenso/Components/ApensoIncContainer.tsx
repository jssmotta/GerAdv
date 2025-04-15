"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ApensoInc from "../Crud/Inc/Apenso";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ApensoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ApensoIncContainer: React.FC<ApensoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/apenso"); // 27012025
    const handleError = () => { };

    return (
        <ApensoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ApensoIncContainer;