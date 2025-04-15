import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import TipoStatusBiuInc from "../Inc/TipoStatusBiu";
import { ITipoStatusBiu } from "../../Interfaces/interface.TipoStatusBiu";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { TipoStatusBiuEmpty } from "@/app/GerAdv_TS/Models/TipoStatusBiu";
import { useWindow } from "@/app/hooks/useWindows";

interface TipoStatusBiuWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedTipoStatusBiu?: ITipoStatusBiu;
    onSuccess: () => void;
    onError: () => void;
}

const TipoStatusBiuWindow: React.FC<TipoStatusBiuWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedTipoStatusBiu,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/tipostatusbiu/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedTipoStatusBiu?.id}`);
        }

    }, [isMobile, router, selectedTipoStatusBiu]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedTipoStatusBiu?.id ?? 0).toString()}
                >
                    <TipoStatusBiuInc
                        id={selectedTipoStatusBiu?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowTipoStatusBiu: React.FC<TipoStatusBiuWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <TipoStatusBiuWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedTipoStatusBiu={TipoStatusBiuEmpty()}>
        </TipoStatusBiuWindow>
    )
};

export default TipoStatusBiuWindow;