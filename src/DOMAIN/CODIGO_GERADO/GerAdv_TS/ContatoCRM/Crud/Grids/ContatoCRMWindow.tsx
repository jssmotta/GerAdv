import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import ContatoCRMInc from "../Inc/ContatoCRM";
import { IContatoCRM } from "../../Interfaces/interface.ContatoCRM";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ContatoCRMEmpty } from "@/app/GerAdv_TS/Models/ContatoCRM";
import { useWindow } from "@/app/hooks/useWindows";

interface ContatoCRMWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedContatoCRM?: IContatoCRM;
    onSuccess: () => void;
    onError: () => void;
}

const ContatoCRMWindow: React.FC<ContatoCRMWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedContatoCRM,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/contatocrm/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedContatoCRM?.id}`);
        }

    }, [isMobile, router, selectedContatoCRM]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={824}
                    newWidth={1440}
                    id={(selectedContatoCRM?.id ?? 0).toString()}
                >
                    <ContatoCRMInc
                        id={selectedContatoCRM?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowContatoCRM: React.FC<ContatoCRMWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ContatoCRMWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedContatoCRM={ContatoCRMEmpty()}>
        </ContatoCRMWindow>
    )
};

export default ContatoCRMWindow;