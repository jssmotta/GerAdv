import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import TipoModeloDocumentoInc from "../Inc/TipoModeloDocumento";
import { ITipoModeloDocumento } from "../../Interfaces/interface.TipoModeloDocumento";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { TipoModeloDocumentoEmpty } from "@/app/GerAdv_TS/Models/TipoModeloDocumento";
import { useWindow } from "@/app/hooks/useWindows";

interface TipoModeloDocumentoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedTipoModeloDocumento?: ITipoModeloDocumento;
    onSuccess: () => void;
    onError: () => void;
}

const TipoModeloDocumentoWindow: React.FC<TipoModeloDocumentoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedTipoModeloDocumento,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/tipomodelodocumento/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedTipoModeloDocumento?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedTipoModeloDocumento]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedTipoModeloDocumento?.id ?? 0).toString()}
                >
                    <TipoModeloDocumentoInc
                        id={selectedTipoModeloDocumento?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowTipoModeloDocumento: React.FC<TipoModeloDocumentoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <TipoModeloDocumentoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedTipoModeloDocumento={TipoModeloDocumentoEmpty()}>
        </TipoModeloDocumentoWindow>
    )
};

export default TipoModeloDocumentoWindow;