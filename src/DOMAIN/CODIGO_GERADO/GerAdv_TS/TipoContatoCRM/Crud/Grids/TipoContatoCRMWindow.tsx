import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import TipoContatoCRMInc from "../Inc/TipoContatoCRM";
import { ITipoContatoCRM } from "../../Interfaces/interface.TipoContatoCRM";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { TipoContatoCRMEmpty } from "@/app/GerAdv_TS/Models/TipoContatoCRM";
import { useWindow } from "@/app/hooks/useWindows";

interface TipoContatoCRMWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedTipoContatoCRM?: ITipoContatoCRM;
    onSuccess: () => void;
    onError: () => void;
}

const TipoContatoCRMWindow: React.FC<TipoContatoCRMWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedTipoContatoCRM,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/tipocontatocrm/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedTipoContatoCRM?.id}`);
        }

    }, [isMobile, router, selectedTipoContatoCRM]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedTipoContatoCRM?.id ?? 0).toString()}
                >
                    <TipoContatoCRMInc
                        id={selectedTipoContatoCRM?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowTipoContatoCRM: React.FC<TipoContatoCRMWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <TipoContatoCRMWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedTipoContatoCRM={TipoContatoCRMEmpty()}>
        </TipoContatoCRMWindow>
    )
};

export default TipoContatoCRMWindow;