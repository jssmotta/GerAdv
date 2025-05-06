"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import DocumentosInc from "../Crud/Inc/Documentos";
import { getParamFromUrl } from "@/app/tools/helpers";

interface DocumentosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const DocumentosIncContainer: React.FC<DocumentosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/documentos"); // 27012025
    const handleError = () => { };

    return (
        <DocumentosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default DocumentosIncContainer;