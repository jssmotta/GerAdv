"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import InstanciaInc from "../Crud/Inc/Instancia";
import { getParamFromUrl } from "@/app/tools/helpers";

interface InstanciaIncContainerProps {
    id: number;
    navigator: INavigator;
}

const InstanciaIncContainer: React.FC<InstanciaIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/instancia"); // 27012025
    const handleError = () => { };

    return (
        <InstanciaInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default InstanciaIncContainer;