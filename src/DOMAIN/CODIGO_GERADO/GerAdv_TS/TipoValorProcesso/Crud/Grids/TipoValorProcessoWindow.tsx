import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import TipoValorProcessoInc from "../Inc/TipoValorProcesso";
import { ITipoValorProcesso } from "../../Interfaces/interface.TipoValorProcesso";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { TipoValorProcessoEmpty } from "@/app/GerAdv_TS/Models/TipoValorProcesso";
import { useWindow } from "@/app/hooks/useWindows";

interface TipoValorProcessoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedTipoValorProcesso?: ITipoValorProcesso;
    onSuccess: () => void;
    onError: () => void;
}

const TipoValorProcessoWindow: React.FC<TipoValorProcessoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedTipoValorProcesso,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/tipovalorprocesso/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedTipoValorProcesso?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedTipoValorProcesso]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedTipoValorProcesso?.id ?? 0).toString()}
                >
                    <TipoValorProcessoInc
                        id={selectedTipoValorProcesso?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowTipoValorProcesso: React.FC<TipoValorProcessoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <TipoValorProcessoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedTipoValorProcesso={TipoValorProcessoEmpty()}>
        </TipoValorProcessoWindow>
    )
};

export default TipoValorProcessoWindow;