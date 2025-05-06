import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import AdvogadosInc from "../Inc/Advogados";
import { IAdvogados } from "../../Interfaces/interface.Advogados";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AdvogadosEmpty } from "@/app/GerAdv_TS/Models/Advogados";
import { useWindow } from "@/app/hooks/useWindows";

interface AdvogadosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAdvogados?: IAdvogados;
    onSuccess: () => void;
    onError: () => void;
}

const AdvogadosWindow: React.FC<AdvogadosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAdvogados,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/advogados/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAdvogados?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedAdvogados]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={905}
                    newWidth={1440}
                    id={(selectedAdvogados?.id ?? 0).toString()}
                >
                    <AdvogadosInc
                        id={selectedAdvogados?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAdvogados: React.FC<AdvogadosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AdvogadosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAdvogados={AdvogadosEmpty()}>
        </AdvogadosWindow>
    )
};

export default AdvogadosWindow;