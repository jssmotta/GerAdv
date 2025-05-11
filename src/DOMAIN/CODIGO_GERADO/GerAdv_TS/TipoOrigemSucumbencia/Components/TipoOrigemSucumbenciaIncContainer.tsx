"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import TipoOrigemSucumbenciaInc from "../Crud/Inc/TipoOrigemSucumbencia";
import { getParamFromUrl } from "@/app/tools/helpers";

interface TipoOrigemSucumbenciaIncContainerProps {
    id: number;
    navigator: INavigator;
}

const TipoOrigemSucumbenciaIncContainer: React.FC<TipoOrigemSucumbenciaIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/tipoorigemsucumbencia"); // 27012025
    const handleError = () => { };

    return (
        <TipoOrigemSucumbenciaInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default TipoOrigemSucumbenciaIncContainer;