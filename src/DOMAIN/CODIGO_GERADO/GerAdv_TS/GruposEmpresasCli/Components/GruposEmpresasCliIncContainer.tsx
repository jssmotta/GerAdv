"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import GruposEmpresasCliInc from "../Crud/Inc/GruposEmpresasCli";
import { getParamFromUrl } from "@/app/tools/helpers";

interface GruposEmpresasCliIncContainerProps {
    id: number;
    navigator: INavigator;
}

const GruposEmpresasCliIncContainer: React.FC<GruposEmpresasCliIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/gruposempresascli"); // 27012025
    const handleError = () => { };

    return (
        <GruposEmpresasCliInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default GruposEmpresasCliIncContainer;