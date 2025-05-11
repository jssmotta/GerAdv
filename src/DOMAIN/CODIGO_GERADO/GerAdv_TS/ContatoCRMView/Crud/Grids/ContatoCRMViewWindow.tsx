import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ContatoCRMViewInc from "../Inc/ContatoCRMView";
import { IContatoCRMView } from "../../Interfaces/interface.ContatoCRMView";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ContatoCRMViewEmpty } from "@/app/GerAdv_TS/Models/ContatoCRMView";
import { useWindow } from "@/app/hooks/useWindows";

interface ContatoCRMViewWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedContatoCRMView?: IContatoCRMView;
    onSuccess: () => void;
    onError: () => void;
}

const ContatoCRMViewWindow: React.FC<ContatoCRMViewWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedContatoCRMView,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/contatocrmview/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedContatoCRMView?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedContatoCRMView]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedContatoCRMView?.id ?? 0).toString()}
                >
                    <ContatoCRMViewInc
                        id={selectedContatoCRMView?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowContatoCRMView: React.FC<ContatoCRMViewWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ContatoCRMViewWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedContatoCRMView={ContatoCRMViewEmpty()}>
        </ContatoCRMViewWindow>
    )
};

export default ContatoCRMViewWindow;