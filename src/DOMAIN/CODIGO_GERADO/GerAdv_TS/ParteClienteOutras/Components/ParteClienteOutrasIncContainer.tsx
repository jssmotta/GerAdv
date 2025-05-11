"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ParteClienteOutrasInc from "../Crud/Inc/ParteClienteOutras";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ParteClienteOutrasIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ParteClienteOutrasIncContainer: React.FC<ParteClienteOutrasIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/parteclienteoutras"); // 27012025
    const handleError = () => { };

    return (
        <ParteClienteOutrasInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ParteClienteOutrasIncContainer;