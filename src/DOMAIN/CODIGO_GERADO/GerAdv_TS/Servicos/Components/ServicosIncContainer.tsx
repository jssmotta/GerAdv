"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ServicosInc from "../Crud/Inc/Servicos";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ServicosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ServicosIncContainer: React.FC<ServicosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/servicos"); // 27012025
    const handleError = () => { };

    return (
        <ServicosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ServicosIncContainer;