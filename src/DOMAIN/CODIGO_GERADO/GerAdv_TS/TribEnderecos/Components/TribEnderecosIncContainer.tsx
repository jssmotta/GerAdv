"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import TribEnderecosInc from "../Crud/Inc/TribEnderecos";
import { getParamFromUrl } from "@/app/tools/helpers";

interface TribEnderecosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const TribEnderecosIncContainer: React.FC<TribEnderecosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/tribenderecos"); // 27012025
    const handleError = () => { };

    return (
        <TribEnderecosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default TribEnderecosIncContainer;