import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import TipoProDespositoInc from "../Inc/TipoProDesposito";
import { ITipoProDesposito } from "../../Interfaces/interface.TipoProDesposito";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { TipoProDespositoEmpty } from "@/app/GerAdv_TS/Models/TipoProDesposito";
import { useWindow } from "@/app/hooks/useWindows";

interface TipoProDespositoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedTipoProDesposito?: ITipoProDesposito;
    onSuccess: () => void;
    onError: () => void;
}

const TipoProDespositoWindow: React.FC<TipoProDespositoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedTipoProDesposito,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/tipoprodesposito/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedTipoProDesposito?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedTipoProDesposito]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedTipoProDesposito?.id ?? 0).toString()}
                >
                    <TipoProDespositoInc
                        id={selectedTipoProDesposito?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowTipoProDesposito: React.FC<TipoProDespositoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <TipoProDespositoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedTipoProDesposito={TipoProDespositoEmpty()}>
        </TipoProDespositoWindow>
    )
};

export default TipoProDespositoWindow;