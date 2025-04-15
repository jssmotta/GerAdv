import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import DocsRecebidosItensInc from "../Inc/DocsRecebidosItens";
import { IDocsRecebidosItens } from "../../Interfaces/interface.DocsRecebidosItens";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { DocsRecebidosItensEmpty } from "@/app/GerAdv_TS/Models/DocsRecebidosItens";
import { useWindow } from "@/app/hooks/useWindows";

interface DocsRecebidosItensWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedDocsRecebidosItens?: IDocsRecebidosItens;
    onSuccess: () => void;
    onError: () => void;
}

const DocsRecebidosItensWindow: React.FC<DocsRecebidosItensWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedDocsRecebidosItens,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/docsrecebidositens/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedDocsRecebidosItens?.id}`);
        }

    }, [isMobile, router, selectedDocsRecebidosItens]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedDocsRecebidosItens?.id ?? 0).toString()}
                >
                    <DocsRecebidosItensInc
                        id={selectedDocsRecebidosItens?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowDocsRecebidosItens: React.FC<DocsRecebidosItensWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <DocsRecebidosItensWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedDocsRecebidosItens={DocsRecebidosItensEmpty()}>
        </DocsRecebidosItensWindow>
    )
};

export default DocsRecebidosItensWindow;