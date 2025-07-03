import React from 'react';
import { render } from '@testing-library/react';
import PontoVirtualAcessosIncContainer from '@/app/GerAdv_TS/PontoVirtualAcessos/Components/PontoVirtualAcessosIncContainer';
// PontoVirtualAcessosIncContainer.test.tsx
// Mock do PontoVirtualAcessosInc
jest.mock('@/app/GerAdv_TS/PontoVirtualAcessos/Crud/Inc/PontoVirtualAcessos', () => (props: any) => (
<div data-testid='pontovirtualacessos-inc-mock' {...props} />
));
describe('PontoVirtualAcessosIncContainer', () => {
  it('deve renderizar PontoVirtualAcessosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <PontoVirtualAcessosIncContainer id={id} navigator={mockNavigator} />
  );
  const pontovirtualacessosInc = getByTestId('pontovirtualacessos-inc-mock');
  expect(pontovirtualacessosInc).toBeInTheDocument();
  expect(pontovirtualacessosInc.getAttribute('id')).toBe(id.toString());

});
});