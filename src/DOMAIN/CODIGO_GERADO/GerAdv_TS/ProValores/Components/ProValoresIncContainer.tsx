"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ProValoresInc from "../Crud/Inc/ProValores";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ProValoresIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ProValoresIncContainer: React.FC<ProValoresIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/provalores"); // 27012025
    const handleError = () => { };

    return (
        <ProValoresInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ProValoresIncContainer;