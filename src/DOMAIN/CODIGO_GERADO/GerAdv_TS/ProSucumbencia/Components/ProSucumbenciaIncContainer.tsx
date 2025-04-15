"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ProSucumbenciaInc from "../Crud/Inc/ProSucumbencia";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ProSucumbenciaIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ProSucumbenciaIncContainer: React.FC<ProSucumbenciaIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/prosucumbencia"); // 27012025
    const handleError = () => { };

    return (
        <ProSucumbenciaInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ProSucumbenciaIncContainer;