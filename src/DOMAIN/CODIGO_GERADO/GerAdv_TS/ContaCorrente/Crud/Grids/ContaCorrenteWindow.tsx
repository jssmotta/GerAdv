import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import ContaCorrenteInc from "../Inc/ContaCorrente";
import { IContaCorrente } from "../../Interfaces/interface.ContaCorrente";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ContaCorrenteEmpty } from "@/app/GerAdv_TS/Models/ContaCorrente";
import { useWindow } from "@/app/hooks/useWindows";

interface ContaCorrenteWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedContaCorrente?: IContaCorrente;
    onSuccess: () => void;
    onError: () => void;
}

const ContaCorrenteWindow: React.FC<ContaCorrenteWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedContaCorrente,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/contacorrente/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedContaCorrente?.id}`);
        }

    }, [isMobile, router, selectedContaCorrente]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={795}
                    newWidth={1440}
                    id={(selectedContaCorrente?.id ?? 0).toString()}
                >
                    <ContaCorrenteInc
                        id={selectedContaCorrente?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowContaCorrente: React.FC<ContaCorrenteWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ContaCorrenteWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedContaCorrente={ContaCorrenteEmpty()}>
        </ContaCorrenteWindow>
    )
};

export default ContaCorrenteWindow;