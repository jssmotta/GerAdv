import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import EscritoriosInc from "../Inc/Escritorios";
import { IEscritorios } from "../../Interfaces/interface.Escritorios";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { EscritoriosEmpty } from "@/app/GerAdv_TS/Models/Escritorios";
import { useWindow } from "@/app/hooks/useWindows";

interface EscritoriosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedEscritorios?: IEscritorios;
    onSuccess: () => void;
    onError: () => void;
}

const EscritoriosWindow: React.FC<EscritoriosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedEscritorios,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/escritorios/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedEscritorios?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedEscritorios]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={704}
                    newWidth={1440}
                    id={(selectedEscritorios?.id ?? 0).toString()}
                >
                    <EscritoriosInc
                        id={selectedEscritorios?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowEscritorios: React.FC<EscritoriosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <EscritoriosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedEscritorios={EscritoriosEmpty()}>
        </EscritoriosWindow>
    )
};

export default EscritoriosWindow;