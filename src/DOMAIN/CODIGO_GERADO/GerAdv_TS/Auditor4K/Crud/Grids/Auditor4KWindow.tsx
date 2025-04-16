import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import Auditor4KInc from "../Inc/Auditor4K";
import { IAuditor4K } from "../../Interfaces/interface.Auditor4K";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { Auditor4KEmpty } from "@/app/GerAdv_TS/Models/Auditor4K";
import { useWindow } from "@/app/hooks/useWindows";

interface Auditor4KWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAuditor4K?: IAuditor4K;
    onSuccess: () => void;
    onError: () => void;
}

const Auditor4KWindow: React.FC<Auditor4KWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAuditor4K,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/auditor4k/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAuditor4K?.id}`);
        }

    }, [isMobile, router, selectedAuditor4K]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedAuditor4K?.id ?? 0).toString()}
                >
                    <Auditor4KInc
                        id={selectedAuditor4K?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAuditor4K: React.FC<Auditor4KWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <Auditor4KWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAuditor4K={Auditor4KEmpty()}>
        </Auditor4KWindow>
    )
};

export default Auditor4KWindow;