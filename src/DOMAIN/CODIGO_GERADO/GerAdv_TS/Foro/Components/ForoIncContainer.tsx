"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ForoInc from "../Crud/Inc/Foro";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ForoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ForoIncContainer: React.FC<ForoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/foro"); // 27012025
    const handleError = () => { };

    return (
        <ForoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ForoIncContainer;