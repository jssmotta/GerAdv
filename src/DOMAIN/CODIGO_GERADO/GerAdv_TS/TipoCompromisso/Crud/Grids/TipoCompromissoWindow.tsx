import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import TipoCompromissoInc from "../Inc/TipoCompromisso";
import { ITipoCompromisso } from "../../Interfaces/interface.TipoCompromisso";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { TipoCompromissoEmpty } from "@/app/GerAdv_TS/Models/TipoCompromisso";
import { useWindow } from "@/app/hooks/useWindows";

interface TipoCompromissoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedTipoCompromisso?: ITipoCompromisso;
    onSuccess: () => void;
    onError: () => void;
}

const TipoCompromissoWindow: React.FC<TipoCompromissoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedTipoCompromisso,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/tipocompromisso/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedTipoCompromisso?.id}`);
        }

    }, [isMobile, router, selectedTipoCompromisso]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedTipoCompromisso?.id ?? 0).toString()}
                >
                    <TipoCompromissoInc
                        id={selectedTipoCompromisso?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowTipoCompromisso: React.FC<TipoCompromissoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <TipoCompromissoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedTipoCompromisso={TipoCompromissoEmpty()}>
        </TipoCompromissoWindow>
    )
};

export default TipoCompromissoWindow;