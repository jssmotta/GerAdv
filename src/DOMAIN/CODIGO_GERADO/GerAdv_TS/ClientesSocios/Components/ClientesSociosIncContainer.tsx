"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ClientesSociosInc from "../Crud/Inc/ClientesSocios";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ClientesSociosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ClientesSociosIncContainer: React.FC<ClientesSociosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/clientessocios"); // 27012025
    const handleError = () => { };

    return (
        <ClientesSociosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ClientesSociosIncContainer;