import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import TipoOrigemSucumbenciaInc from "../Inc/TipoOrigemSucumbencia";
import { ITipoOrigemSucumbencia } from "../../Interfaces/interface.TipoOrigemSucumbencia";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { TipoOrigemSucumbenciaEmpty } from "@/app/GerAdv_TS/Models/TipoOrigemSucumbencia";
import { useWindow } from "@/app/hooks/useWindows";

interface TipoOrigemSucumbenciaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedTipoOrigemSucumbencia?: ITipoOrigemSucumbencia;
    onSuccess: () => void;
    onError: () => void;
}

const TipoOrigemSucumbenciaWindow: React.FC<TipoOrigemSucumbenciaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedTipoOrigemSucumbencia,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/tipoorigemsucumbencia/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedTipoOrigemSucumbencia?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedTipoOrigemSucumbencia]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedTipoOrigemSucumbencia?.id ?? 0).toString()}
                >
                    <TipoOrigemSucumbenciaInc
                        id={selectedTipoOrigemSucumbencia?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowTipoOrigemSucumbencia: React.FC<TipoOrigemSucumbenciaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <TipoOrigemSucumbenciaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedTipoOrigemSucumbencia={TipoOrigemSucumbenciaEmpty()}>
        </TipoOrigemSucumbenciaWindow>
    )
};

export default TipoOrigemSucumbenciaWindow;