import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ContatoCRMOperadorInc from "../Inc/ContatoCRMOperador";
import { IContatoCRMOperador } from "../../Interfaces/interface.ContatoCRMOperador";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ContatoCRMOperadorEmpty } from "@/app/GerAdv_TS/Models/ContatoCRMOperador";
import { useWindow } from "@/app/hooks/useWindows";

interface ContatoCRMOperadorWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedContatoCRMOperador?: IContatoCRMOperador;
    onSuccess: () => void;
    onError: () => void;
}

const ContatoCRMOperadorWindow: React.FC<ContatoCRMOperadorWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedContatoCRMOperador,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/contatocrmoperador/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedContatoCRMOperador?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedContatoCRMOperador]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedContatoCRMOperador?.id ?? 0).toString()}
                >
                    <ContatoCRMOperadorInc
                        id={selectedContatoCRMOperador?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowContatoCRMOperador: React.FC<ContatoCRMOperadorWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ContatoCRMOperadorWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedContatoCRMOperador={ContatoCRMOperadorEmpty()}>
        </ContatoCRMOperadorWindow>
    )
};

export default ContatoCRMOperadorWindow;