"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ModelosDocumentosInc from "../Crud/Inc/ModelosDocumentos";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ModelosDocumentosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ModelosDocumentosIncContainer: React.FC<ModelosDocumentosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/modelosdocumentos"); // 27012025
    const handleError = () => { };

    return (
        <ModelosDocumentosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ModelosDocumentosIncContainer;