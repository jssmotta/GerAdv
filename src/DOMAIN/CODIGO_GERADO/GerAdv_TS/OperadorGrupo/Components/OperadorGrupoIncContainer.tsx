"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import OperadorGrupoInc from "../Crud/Inc/OperadorGrupo";
import { getParamFromUrl } from "@/app/tools/helpers";

interface OperadorGrupoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const OperadorGrupoIncContainer: React.FC<OperadorGrupoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/operadorgrupo"); // 27012025
    const handleError = () => { };

    return (
        <OperadorGrupoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default OperadorGrupoIncContainer;