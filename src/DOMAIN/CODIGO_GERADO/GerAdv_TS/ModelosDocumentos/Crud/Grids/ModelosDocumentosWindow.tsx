import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import ModelosDocumentosInc from "../Inc/ModelosDocumentos";
import { IModelosDocumentos } from "../../Interfaces/interface.ModelosDocumentos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ModelosDocumentosEmpty } from "@/app/GerAdv_TS/Models/ModelosDocumentos";
import { useWindow } from "@/app/hooks/useWindows";

interface ModelosDocumentosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedModelosDocumentos?: IModelosDocumentos;
    onSuccess: () => void;
    onError: () => void;
}

const ModelosDocumentosWindow: React.FC<ModelosDocumentosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedModelosDocumentos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/modelosdocumentos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedModelosDocumentos?.id}`);
        }

    }, [isMobile, router, selectedModelosDocumentos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={702}
                    newWidth={1440}
                    id={(selectedModelosDocumentos?.id ?? 0).toString()}
                >
                    <ModelosDocumentosInc
                        id={selectedModelosDocumentos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowModelosDocumentos: React.FC<ModelosDocumentosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ModelosDocumentosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedModelosDocumentos={ModelosDocumentosEmpty()}>
        </ModelosDocumentosWindow>
    )
};

export default ModelosDocumentosWindow;