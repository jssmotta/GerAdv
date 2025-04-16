import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import ProTipoBaixaInc from "../Inc/ProTipoBaixa";
import { IProTipoBaixa } from "../../Interfaces/interface.ProTipoBaixa";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProTipoBaixaEmpty } from "@/app/GerAdv_TS/Models/ProTipoBaixa";
import { useWindow } from "@/app/hooks/useWindows";

interface ProTipoBaixaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProTipoBaixa?: IProTipoBaixa;
    onSuccess: () => void;
    onError: () => void;
}

const ProTipoBaixaWindow: React.FC<ProTipoBaixaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProTipoBaixa,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/protipobaixa/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProTipoBaixa?.id}`);
        }

    }, [isMobile, router, selectedProTipoBaixa]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedProTipoBaixa?.id ?? 0).toString()}
                >
                    <ProTipoBaixaInc
                        id={selectedProTipoBaixa?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProTipoBaixa: React.FC<ProTipoBaixaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProTipoBaixaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProTipoBaixa={ProTipoBaixaEmpty()}>
        </ProTipoBaixaWindow>
    )
};

export default ProTipoBaixaWindow;