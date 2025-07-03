import React from 'react';
import { render } from '@testing-library/react';
import ProProcuradoresIncContainer from '@/app/GerAdv_TS/ProProcuradores/Components/ProProcuradoresIncContainer';
// ProProcuradoresIncContainer.test.tsx
// Mock do ProProcuradoresInc
jest.mock('@/app/GerAdv_TS/ProProcuradores/Crud/Inc/ProProcuradores', () => (props: any) => (
<div data-testid='proprocuradores-inc-mock' {...props} />
));
describe('ProProcuradoresIncContainer', () => {
  it('deve renderizar ProProcuradoresInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ProProcuradoresIncContainer id={id} navigator={mockNavigator} />
  );
  const proprocuradoresInc = getByTestId('proprocuradores-inc-mock');
  expect(proprocuradoresInc).toBeInTheDocument();
  expect(proprocuradoresInc.getAttribute('id')).toBe(id.toString());

});
});