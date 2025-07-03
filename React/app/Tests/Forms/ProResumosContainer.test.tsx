import React from 'react';
import { render } from '@testing-library/react';
import ProResumosIncContainer from '@/app/GerAdv_TS/ProResumos/Components/ProResumosIncContainer';
// ProResumosIncContainer.test.tsx
// Mock do ProResumosInc
jest.mock('@/app/GerAdv_TS/ProResumos/Crud/Inc/ProResumos', () => (props: any) => (
<div data-testid='proresumos-inc-mock' {...props} />
));
describe('ProResumosIncContainer', () => {
  it('deve renderizar ProResumosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ProResumosIncContainer id={id} navigator={mockNavigator} />
  );
  const proresumosInc = getByTestId('proresumos-inc-mock');
  expect(proresumosInc).toBeInTheDocument();
  expect(proresumosInc.getAttribute('id')).toBe(id.toString());

});
});