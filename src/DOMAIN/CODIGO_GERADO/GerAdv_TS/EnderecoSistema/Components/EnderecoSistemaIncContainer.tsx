"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import EnderecoSistemaInc from "../Crud/Inc/EnderecoSistema";
import { getParamFromUrl } from "@/app/tools/helpers";

interface EnderecoSistemaIncContainerProps {
    id: number;
    navigator: INavigator;
}

const EnderecoSistemaIncContainer: React.FC<EnderecoSistemaIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/enderecosistema"); // 27012025
    const handleError = () => { };

    return (
        <EnderecoSistemaInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default EnderecoSistemaIncContainer;