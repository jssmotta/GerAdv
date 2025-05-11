"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ClientesInc from "../Crud/Inc/Clientes";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ClientesIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ClientesIncContainer: React.FC<ClientesIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/clientes"); // 27012025
    const handleError = () => { };

    return (
        <ClientesInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ClientesIncContainer;