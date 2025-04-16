"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import TipoEnderecoInc from "../Crud/Inc/TipoEndereco";
import { getParamFromUrl } from "@/app/tools/helpers";

interface TipoEnderecoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const TipoEnderecoIncContainer: React.FC<TipoEnderecoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/tipoendereco"); // 27012025
    const handleError = () => { };

    return (
        <TipoEnderecoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default TipoEnderecoIncContainer;