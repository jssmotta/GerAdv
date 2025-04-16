import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import TipoRecursoInc from "../Inc/TipoRecurso";
import { ITipoRecurso } from "../../Interfaces/interface.TipoRecurso";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { TipoRecursoEmpty } from "@/app/GerAdv_TS/Models/TipoRecurso";
import { useWindow } from "@/app/hooks/useWindows";

interface TipoRecursoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedTipoRecurso?: ITipoRecurso;
    onSuccess: () => void;
    onError: () => void;
}

const TipoRecursoWindow: React.FC<TipoRecursoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedTipoRecurso,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/tiporecurso/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedTipoRecurso?.id}`);
        }

    }, [isMobile, router, selectedTipoRecurso]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedTipoRecurso?.id ?? 0).toString()}
                >
                    <TipoRecursoInc
                        id={selectedTipoRecurso?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowTipoRecurso: React.FC<TipoRecursoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <TipoRecursoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedTipoRecurso={TipoRecursoEmpty()}>
        </TipoRecursoWindow>
    )
};

export default TipoRecursoWindow;