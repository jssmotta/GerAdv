import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import GUTTipoInc from "../Inc/GUTTipo";
import { IGUTTipo } from "../../Interfaces/interface.GUTTipo";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { GUTTipoEmpty } from "@/app/GerAdv_TS/Models/GUTTipo";
import { useWindow } from "@/app/hooks/useWindows";

interface GUTTipoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedGUTTipo?: IGUTTipo;
    onSuccess: () => void;
    onError: () => void;
}

const GUTTipoWindow: React.FC<GUTTipoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedGUTTipo,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/guttipo/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedGUTTipo?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedGUTTipo]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedGUTTipo?.id ?? 0).toString()}
                >
                    <GUTTipoInc
                        id={selectedGUTTipo?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowGUTTipo: React.FC<GUTTipoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <GUTTipoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedGUTTipo={GUTTipoEmpty()}>
        </GUTTipoWindow>
    )
};

export default GUTTipoWindow;