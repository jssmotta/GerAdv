import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import DocumentosInc from "../Inc/Documentos";
import { IDocumentos } from "../../Interfaces/interface.Documentos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { DocumentosEmpty } from "@/app/GerAdv_TS/Models/Documentos";
import { useWindow } from "@/app/hooks/useWindows";

interface DocumentosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedDocumentos?: IDocumentos;
    onSuccess: () => void;
    onError: () => void;
}

const DocumentosWindow: React.FC<DocumentosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedDocumentos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/documentos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedDocumentos?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedDocumentos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedDocumentos?.id ?? 0).toString()}
                >
                    <DocumentosInc
                        id={selectedDocumentos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowDocumentos: React.FC<DocumentosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <DocumentosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedDocumentos={DocumentosEmpty()}>
        </DocumentosWindow>
    )
};

export default DocumentosWindow;