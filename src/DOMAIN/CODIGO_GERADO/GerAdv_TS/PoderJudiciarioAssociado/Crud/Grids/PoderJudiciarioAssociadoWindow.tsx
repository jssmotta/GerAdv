import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import PoderJudiciarioAssociadoInc from "../Inc/PoderJudiciarioAssociado";
import { IPoderJudiciarioAssociado } from "../../Interfaces/interface.PoderJudiciarioAssociado";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { PoderJudiciarioAssociadoEmpty } from "@/app/GerAdv_TS/Models/PoderJudiciarioAssociado";
import { useWindow } from "@/app/hooks/useWindows";

interface PoderJudiciarioAssociadoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedPoderJudiciarioAssociado?: IPoderJudiciarioAssociado;
    onSuccess: () => void;
    onError: () => void;
}

const PoderJudiciarioAssociadoWindow: React.FC<PoderJudiciarioAssociadoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedPoderJudiciarioAssociado,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/poderjudiciarioassociado/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedPoderJudiciarioAssociado?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedPoderJudiciarioAssociado]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={657}
                    newWidth={1440}
                    id={(selectedPoderJudiciarioAssociado?.id ?? 0).toString()}
                >
                    <PoderJudiciarioAssociadoInc
                        id={selectedPoderJudiciarioAssociado?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowPoderJudiciarioAssociado: React.FC<PoderJudiciarioAssociadoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <PoderJudiciarioAssociadoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedPoderJudiciarioAssociado={PoderJudiciarioAssociadoEmpty()}>
        </PoderJudiciarioAssociadoWindow>
    )
};

export default PoderJudiciarioAssociadoWindow;